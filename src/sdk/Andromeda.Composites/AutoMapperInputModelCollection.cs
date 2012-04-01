using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Andromeda.Common.Configuration;
using Andromeda.Composites.Conversion;
using Andromeda.Framework.AgentMetadata;
using Andromeda.Framework.AgentMetadata.Extensions;
using Andromeda.Framework.Cqrs;
using Andromeda.Framework.Models;

namespace Andromeda.Composites
{
	public class AutoMapperInputModelCollection : IInputModelMapCollection
	{
		public AutoMapperInputModelCollection()
		{
			Mapper.Reset();
		}

		public IEnumerable<IPartMetadata> Commands
		{
			get
			{
				return
					Mapper.GetAllTypeMaps().Where(m => typeof(ICommand).IsAssignableFrom(m.DestinationType)).Select(
						m => m.DestinationType.GetPartMetadata());
			}
		}

		public IEnumerable<ITypeMetadata> InputModels
		{
			get
			{
				return
					Mapper.GetAllTypeMaps().Where(m => typeof(IInputModel).IsAssignableFrom(m.SourceType)).Select(
						m => m.SourceType.GetMetadata());
			}
		}

		public bool CommandIsMapped<TCommand>() where TCommand : ICommand
		{
			return Mapper.GetAllTypeMaps().Any(m => m.DestinationType == typeof(TCommand));
		}

		public ICommand GetCommand<TSourceInputModel>(TSourceInputModel inputModel) where TSourceInputModel : IInputModel
		{
			var commandMetadata = GetCommandMetadataForInputModel(inputModel.GetType());

			return Mapper.Map(inputModel, inputModel.GetType(), commandMetadata.Type) as ICommand;
		}

		public IPartMetadata GetCommandMetadataForInputModel(Type inputModelType)
		{
			if (!typeof(IInputModel).IsAssignableFrom(inputModelType))
			{
				throw new InvalidTypeSettingException(inputModelType.FullName, typeof(IInputModel), inputModelType.GetType());
			}

			var map = Mapper.GetAllTypeMaps().Where(m => m.SourceType == inputModelType).FirstOrDefault();

			if (map == null)
			{
				throw new InputModelNotRegisteredException(inputModelType);
			}

			var commandType = map.DestinationType;

			return commandType.GetPartMetadata();
		}

		public IPartMetadata GetCommandMetadataForInputModel(IInputModel model)
		{
			return GetCommandMetadataForInputModel(model.GetType());
		}

		public IPartMetadata GetCommandMetadataForInputModel<TInputModel>() where TInputModel : IInputModel
		{
			return GetCommandMetadataForInputModel(typeof(TInputModel));
		}

		public Type GetInputModelTypeForCommandName(string commandName)
		{
			var type =
				Mapper.GetAllTypeMaps().Where(t => t.DestinationType.Name == commandName).Select(t => t.SourceType).FirstOrDefault();

			if (type == null)
			{
				throw new CannotMapCommandException(commandName, InputModels.Select(m => m.Type.FullName));
			}

			return type;
		}

		public bool InputModelIsMapped<TInputModel>() where TInputModel : IInputModel
		{
			return Mapper.GetAllTypeMaps().Any(m => m.SourceType == typeof(TInputModel));
		}

		public void RegisterInputModel<TSourceInputModel, TDestinationCommand>() where TSourceInputModel : IInputModel
			where TDestinationCommand : ICommand
		{
			RegisterInputModel<TSourceInputModel, TDestinationCommand>(null);
		}

		public void RegisterInputModel<TSourceInputModel, TDestinationCommand>(
			Func<TSourceInputModel, TDestinationCommand> customMap) where TSourceInputModel : IInputModel
			where TDestinationCommand : ICommand
		{
			if (InputModelIsMapped<TSourceInputModel>())
			{
				throw new InputModelAlreadyRegisteredException(typeof(TSourceInputModel).FullName);
			}

			if (CommandIsMapped<TDestinationCommand>())
			{
				throw new CommandAlreadyMappedException(typeof(TDestinationCommand).FullName);
			}

			var expression = Mapper.CreateMap<TSourceInputModel, TDestinationCommand>();
			if (customMap != null)
			{
				expression.ConvertUsing(customMap);
			}
		}
	}
}