// using FluentValidation;
// using Own.WebApi.Contracts.v1.Requests;

// namespace Own.WebApi.Validators
// {
//     public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
//     {
//         public CreateUserRequestValidator()
//         {
//             RuleFor(x => x.UserName)
//                 .NotEmpty();
//             RuleFor(x => x.LoginPwd)
//                 .NotEmpty()
//                 .MinimumLength(3);
//         }
//     }
// }
