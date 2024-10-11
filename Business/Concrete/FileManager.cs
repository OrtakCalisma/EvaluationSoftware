using Autofac.Core;
using Business.Abstract;
using Business.Constans;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helper.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FileManager : IFileService
    {
        IFileHelper _fileHelper;
        IFileDal _fileDal;
        public FileManager(IFileHelper fileHelper, IFileDal fileDal)
        {
            _fileHelper = fileHelper;
            _fileDal = fileDal;
        }
        public IResult Add(IFormFile file)
        {
            //IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));

            //if (result != null)
            //{
            //    return result;
            //}

            HRS hRS = new HRS();

            var filePath = _fileHelper.Upload(file, PathConstans.FilePath);

            var streamReader = new StreamReader(PathConstans.FilePath + filePath, Encoding.GetEncoding("UTF-8"));

            string row = null;

            while ((row = streamReader.ReadLine()) != null && row.Length > 1)
            {
                var hrs = new HRS()
                {
                    DoorsId = row.Split(Delimiter.FileDelimiter)[0],
                    Description = row.Split(Delimiter.FileDelimiter)[1],
                    MoC = row.Split(Delimiter.FileDelimiter)[2],
                    Version = "1",
                };
                _fileDal.Add(hrs);
            }
            streamReader.Close();

            return new SuccessResult("File is Uploaded.");
        }

        public IDataResult<HRS> Get(string fileName)
        {
            return new SuccessDataResult<HRS>(_fileDal.Get(x=> x.Version == "1"));
        }
        public IDataResult<List<HRS>> GetAll(string fileName)
        {
            return new SuccessDataResult<List<HRS>>(_fileDal.GetList(x => x.Version == "1").ToList());
        }

        //public IDataResult<List<Faults>> GetList()
        //{
        //    return new SuccessDataResult<List<Faults>>(_faultDal.GetList().ToList());
        //}
    }
}
