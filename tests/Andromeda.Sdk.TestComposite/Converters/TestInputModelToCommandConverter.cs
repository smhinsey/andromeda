﻿namespace Andromeda.Sdk.TestComposite.Converters
{
	//public class TestInputModelToCommandConverter : IInputToCommandConverter
	//{
	//    public Type CommandType
	//    {
	//        get
	//        {
	//            return typeof(TestCommand);
	//        }
	//    }

	//    public Type InputModelType
	//    {
	//        get
	//        {
	//            return typeof(TestInputModel);
	//        }
	//    }

	//    public ICommand Convert(ResolutionContext context)
	//    {
	//        var source = context.SourceValue as TestInputModel;
	//        var command = context.DestinationValue as TestCommand;

	//        if (source == null || command == null)
	//        {
	//            throw new CannotCreateInputModelException(InputModelType.Name);
	//        }

	//        command.Number = source.Number;

	//        return command;
	//    }
	//}
}