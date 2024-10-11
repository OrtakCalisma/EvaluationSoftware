using Core.Repositories.EentityFramework.Abstract;
using Core.Utilities.Results;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IFileDal : IEntityRepository<HRS>
    {
    }
}
