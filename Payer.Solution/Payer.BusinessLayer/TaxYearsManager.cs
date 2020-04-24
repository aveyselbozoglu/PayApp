using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payer.DataAccessLayer.EntityFramework;
using Payer.Entities;

namespace Payer.BusinessLayer
{
    public class TaxYearsManager
    {
        private BusinessLayerResult<TaxYear> blResultTaxYear = new BusinessLayerResult<TaxYear>();
        private Repository<TaxYear> repositoryTaxYear = new Repository<TaxYear>();


        public BusinessLayerResult<TaxYear> GetAllTaxYears()
        {
            var resultDb = repositoryTaxYear.List();

            if (resultDb.Count > 0)
            {
                blResultTaxYear.BlResultList = resultDb;
            }

            return blResultTaxYear;
        }
    }
}
