////using System.Linq;
//using System;
//using FluentValidation;

//using NAd.Ncqrs.Events;

//using Ncqrs;

////using NAd.Commanding.Commands;

//namespace NAd.Ncqrs.Domain.Validators
//{
//    public class CreateNewClassifiedValidator : AbstractValidator<CreateNewClassifiedCommand>
//    {
//        public CreateNewClassifiedValidator()
//        {
//            //RuleFor(command => command.Id).NotEqual(Guid.Empty);
//            RuleFor(cmd => cmd.Name).Length(1, 140);
//        }
//    }
//}