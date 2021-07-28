using AutoMapper;
using FruitShop.Application.Interfaces;
using FruitShop.Application.ViewModels;
using FruitShop.Application.Wrappers;
using FruitShop.Auth.Services;
using FruitShop.Domain.Entities;
using FruitShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace FruitShop.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public bool Delete(long Id)
        {
            return _userRepository.Delete(Get(Id));
        }

        public PagedResponse<List<UserViewModel>> Get(int pageNumber, int pageSize)
        {
            var pagedUsers = _userRepository.GetUsers(pageNumber, pageSize);
            return new PagedResponse<List<UserViewModel>>(_mapper.Map<List<UserViewModel>>(pagedUsers.users), pagedUsers.pageInfo);
        }

        public Response<UserViewModel> GetById(long Id)
        {
            return new Response<UserViewModel>(_mapper.Map<UserViewModel>(Get(Id)));
        }

        public void Insert(UserViewModel userViewModel)
        {
            if (userViewModel.Id > 0)
            {
                throw new Exception("O Id do usuário precisa ser 0 (zero) para que seja possível efetuar a inclusão.");
            }

            User user = _mapper.Map<User>(userViewModel);
            user.Password = ComputeMD5Hash(user.Password);
            _userRepository.Create(user);
        }

        public void Update(UserViewModel userViewModel)
        {
            User dbUser = Get(userViewModel.Id);

            User vmUser = _mapper.Map<User>(userViewModel);
            vmUser.Password = string.IsNullOrEmpty(vmUser.Password) ? dbUser.Password : ComputeMD5Hash(vmUser.Password);
            vmUser.Active = true;

            _userRepository.Update(vmUser);
        }

        public UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestViewModel userAuthenticate)
        {
            if (string.IsNullOrEmpty(userAuthenticate.Email) || string.IsNullOrEmpty(userAuthenticate.Password))
            {
                throw new Exception("O e-mail e a senha são obrigatórios.");
            }

            userAuthenticate.Password = ComputeMD5Hash(userAuthenticate.Password);

            User user = _userRepository.Find(x => x.Active &&
                                             x.Email.ToLower().Equals(userAuthenticate.Email.ToLower()) &&
                                             x.Password.Equals(userAuthenticate.Password));
            if (user == null)
            {
                throw new Exception("E-mail e/ou senha inválidos.");
            }

            return new UserAuthenticateResponseViewModel(_mapper.Map<UserViewModel>(user), TokenService.GenerateToken(user));
        }

        private User Get(long Id)
        {
            User user = _userRepository.Find(a => a.Id == Id && a.Active);

            if (user == null)
            {
                throw new Exception("Usuário não encontrado!");
            }

            return user;
        }

        private string ComputeMD5Hash(string text)
        {
            //TODO: include in the appsettings
            string prefix = "f933dba55aed4f1cbd44edad88692588";
            string suffix = "7b69829007af4851a2f63077ea56f06c";

            using MD5 md5 = MD5.Create();
            byte[] retVal = md5.ComputeHash(Encoding.Unicode.GetBytes($"{prefix}-{text}-{suffix}"));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
