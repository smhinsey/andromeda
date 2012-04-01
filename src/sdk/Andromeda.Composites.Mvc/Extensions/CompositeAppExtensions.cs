﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Andromeda.Common.Extensions;
using Andromeda.Common.Storage;
using Andromeda.Common.Storage.Binary;
using Andromeda.Composites.Conversion;
using Andromeda.Composites.Mvc.Binders;
using Andromeda.Framework.Models;

namespace Andromeda.Composites.Mvc.Extensions
{
	public static class CompositeAppExtensions
	{
		public static IInputModel GetInputModelFromCommandName(this ICompositeApp composite, string commandName, IValueProvider valueProvider, HttpFileCollectionBase files)
		{
			var ignoreProperties = new List<string>();

			var inputModelType = composite.GetInputModelTypeForCommandName(commandName);

			var commandType = composite.Commands.Where(x => x.Name == commandName).Select(x => x.Type).FirstOrDefault();

			var inputModel = Activator.CreateInstance(inputModelType) as IInputModel;

			if (inputModel == null)
			{
				throw new CannotCreateInputModelException(inputModelType, commandName);
			}

			var modelProperties = inputModel.GetType().GetProperties();
			foreach (var property in modelProperties)
			{
				var propValue = valueProvider.GetValue(property.Name);
				try
				{
					var file = files[property.Name];
					if (property.PropertyType == typeof(HttpPostedFileBase) && file != null && file.ContentLength > 0)
					{
						var blobService = DependencyResolver.Current.GetService<IBlobStorage>();

						using (var memorySteam = new MemoryStream())
						{
							file.InputStream.CopyTo(memorySteam);
							
							var blob = DependencyResolver.Current.GetService<IBlob>();
							blob.Content = memorySteam.ToArray();
							blob.ContentType = file.ContentType;

							var blobUri = blobService.Put(blob, file.FileName);

							var blobUrlPropertyName = string.Format("{0}Url", property.Name);
							var blobUrlProperty = modelProperties.Where(p => p.Name == blobUrlPropertyName).FirstOrDefault();

							if (blobUrlProperty != null && blobUrlProperty.CanWrite)
							{
								var existingBlobUri = valueProvider.GetValue(blobUrlPropertyName);
								if (existingBlobUri != null && !string.IsNullOrEmpty(existingBlobUri.AttemptedValue))
								{
									var uri = new Uri(existingBlobUri.AttemptedValue);
									if (blobService.Exists(uri))
									{
										blobService.Delete(uri);
									}
								}

								ignoreProperties.Add(blobUrlPropertyName);
								blobUrlProperty.SetValue(inputModel, blobUri.ToString(), null);
							}
						}
					}
					else if (!ignoreProperties.Contains(property.Name))
					{
						var value = (property.Name == "CommandType")
										? commandType
										: (propValue == null) ? null : propValue.ConvertTo(property.PropertyType);

						if (property.PropertyType == typeof(string) && value == null)
						{
							value = string.Empty;
						}

						if (property.CanWrite)
						{
							property.SetValue(inputModel, value, null);
						}
					}
				}
				catch (Exception e)
				{
					throw new CannotSetInputModelPropertyValues(inputModel.GetType().Name, property.Name, e);
				}
			}

			return inputModel;
		}
	}
}