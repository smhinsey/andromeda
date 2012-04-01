using System;
using System.Collections.Generic;
using Andromeda.Framework.AgentMetadata;
using Andromeda.Framework.Cqrs;
using Andromeda.Framework.Models;

namespace Andromeda.Composites
{
	public interface IInputModelMapCollection
	{
		IEnumerable<IPartMetadata> Commands { get; }

		IEnumerable<ITypeMetadata> InputModels { get; }

		bool CommandIsMapped<TCommand>() where TCommand : ICommand;

		ICommand GetCommand<TSourceInputModel>(TSourceInputModel inputModel) where TSourceInputModel : IInputModel;

		IPartMetadata GetCommandMetadataForInputModel(Type inputModelType);

		IPartMetadata GetCommandMetadataForInputModel<TSourceInputModel>() where TSourceInputModel : IInputModel;

		IPartMetadata GetCommandMetadataForInputModel(IInputModel model);

		Type GetInputModelTypeForCommandName(string commandName);

		bool InputModelIsMapped<TInputModel>() where TInputModel : IInputModel;

		void RegisterInputModel<TSourceInputModel, TDestinationCommand>() where TSourceInputModel : IInputModel
			where TDestinationCommand : ICommand;

		void RegisterInputModel<TSourceInputModel, TDestinationCommand>(
			Func<TSourceInputModel, TDestinationCommand> customMap) where TSourceInputModel : IInputModel
			where TDestinationCommand : ICommand;
	}
}