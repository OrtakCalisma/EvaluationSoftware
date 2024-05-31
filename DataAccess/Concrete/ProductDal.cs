﻿using Core.Repositories.EntityFramework.Concrete;
using DataAccess.Abstract;
using DataAccess.Context.EntityFramework;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ProductDal : EfEntityRepositoryBase<Product, EntityFrameworkContext>, IProductDal
    {

    }
}
