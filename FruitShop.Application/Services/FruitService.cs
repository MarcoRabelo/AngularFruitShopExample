using AutoMapper;
using FruitShop.Application.Interfaces;
using FruitShop.Application.ViewModels;
using FruitShop.Application.Wrappers;
using FruitShop.Domain.Entities;
using FruitShop.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace FruitShop.Application.Services
{
    public class FruitService : IFruitService
    {
        private readonly IFruitRepository _fruitRepository;
        private readonly IMapper _mapper;

        public FruitService(IFruitRepository FruitRepository, IMapper mapper)
        {
            _fruitRepository = FruitRepository;
            _mapper = mapper;
        }

        public bool Delete(long id)
        {
            return _fruitRepository.Delete(Get(id));
        }

        public IEnumerable<FruitViewModel> GetAll()
        {
            return _mapper.Map<List<FruitViewModel>>(_fruitRepository.GetAll());
        }

        public PagedResponse<List<FruitViewModel>> Get(int pageNumber, int pageSize)
        {
            var paged = _fruitRepository.Get(pageNumber, pageSize);
            return new PagedResponse<List<FruitViewModel>>(_mapper.Map<List<FruitViewModel>>(paged.fruits), paged.pageInfo);
        }

        public Response<FruitViewModel> GetById(long Id)
        {
            return new Response<FruitViewModel>(_mapper.Map<FruitViewModel>(Get(Id)));
        }

        public void Insert(FruitViewModel FruitViewModel)
        {
            if (FruitViewModel.Id > 0)
            {
                throw new Exception("O Id da fruta precisa ser 0 (zero) para que seja possível efetuar a inclusão.");
            }
            _fruitRepository.Create(_mapper.Map<Fruit>(FruitViewModel));
        }

        public void Update(FruitViewModel FruitViewModel)
        {
            Get(FruitViewModel.Id);
            Fruit fruit = _mapper.Map<Fruit>(FruitViewModel);
            fruit.Active = true;
            _fruitRepository.Update(fruit);
        }

        public void AddToCart(long id, long qtt)
        {
            Fruit fruit = Get(id);

            fruit.Stock -= qtt;

            if (fruit.Stock < 0)
            {
                throw new Exception("Quantidade insuficiente desta Fruta no estoque!");
            }

            _fruitRepository.Update(fruit);
        }

        private Fruit Get(long Id)
        {
            Fruit fruit = _fruitRepository.Find(a => a.Id == Id && a.Active);

            if (fruit == null)
            {
                throw new Exception("Fruta não encontrada!");
            }

            return fruit;
        }
    }
}
