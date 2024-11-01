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
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                    Revision = "1",
                    Baseline = "1.0",
                    ProjectName = "C130"
                };
                _fileDal.Add(hrs);
            }
            streamReader.Close();

            return new SuccessResult("File is Uploaded.");
        }

        public IDataResult<HRS> Get(string? fileName)
        {
            return new SuccessDataResult<HRS>(_fileDal.Get(x=> x.Revision == "1"));
        }
        public IDataResult<List<HRS>> GetAll()
        {
            return new SuccessDataResult<List<HRS>>(_fileDal.GetList().ToList());
        }
        public IDataResult<int> GetCount()
        {
            return new SuccessDataResult<int>(_fileDal.GetCount());
        }
        public IDataResult<List<HRS>> GetByProjectName(string projectName)
        {
            return new SuccessDataResult<List<HRS>>(_fileDal.GetList(x => x.ProjectName == projectName).ToList());
        }
        public IDataResult<List<HRS>> GetByBaselineId(string baselineId)
        {
            return new SuccessDataResult<List<HRS>>(_fileDal.GetList(x => x.Baseline == baselineId).ToList());
        }
        public IDataResult<List<HRS>> GetBy(string? baselineId, string? projectName, string? mocLevel, string? revision)
        {
            var result = _fileDal.GetList();

            if (baselineId != null)
            {
                result = result.Where(x => x.Baseline == baselineId).ToList();
            }
            if (projectName != null)
            {
                result = result.Where(x => x.ProjectName == projectName).ToList();
            }
            if (mocLevel != null)
            {
                result = result.Where(x => x.MoC == mocLevel).ToList();
            }
            if (revision != null)
            {
                result = result.Where(x => x.Revision == revision).ToList();
            }

            return new SuccessDataResult<List<HRS>>(result.ToList());
        }
        //var result = _fileDal.GetList(x=> !baselineId.IsNullOrEmpty() ? x.Baseline == baselineId : x.Baseline == x.Baseline
        //                                          && !projectName.IsNullOrEmpty() ? x.ProjectName == projectName : x.ProjectName == x.ProjectName
        //                                          && !mocLevel.IsNullOrEmpty() ? x.MoC == mocLevel : x.MoC == x.MoC
        //                                          && !revision.IsNullOrEmpty() ? x.Revision == revision : x.Revision == x.Revision
        //                                          ).ToList();

    }
}
