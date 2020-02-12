using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using MF.Entity;
using MF.Entity.UnitofWork;

namespace MF.Domain.Service
{

    public class CityServiceAsync<Tv, Te> : GenericServiceAsync<Tv, Te>
                                                where Tv : CityViewModel
                                                where Te : City
    {
        //DI must be implemented specific service as well beside GenericAsyncService constructor
        public CityServiceAsync(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }

        //add here any custom service method or override genericasync service method
        //...
    }

}
