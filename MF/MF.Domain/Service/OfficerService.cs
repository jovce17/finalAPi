﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using MF.Entity;
using MF.Entity.UnitofWork;

namespace MF.Domain.Service
{

    public class OfficeService<Tv, Te> : GenericService<Tv, Te>
                                                where Tv : OfficeViewModel
                                                where Te : Office
    {
        //DI must be implemented in specific service as well beside GenericService constructor
        public OfficeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }

        //add here any custom service method or override generic service method
        public bool DoNothing()
        {
            return true;
        }
    }

}
