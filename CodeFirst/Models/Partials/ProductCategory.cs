using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CodeFirst.Helpers;
using System.Threading;

namespace CodeFirst.Models
{
    public partial class ProductCategory
    {
        private SampleContext db = new SampleContext();

        public static ProductCategory Instance
        {
            get { return new ProductCategory(); }
        }

        public IEnumerable<ProductCategory> findAll()
        {
            return this.db.ProductCategory.Include(pc => pc.Translations);
        }

        public string getName()
        {
            var culture = CultureHelper.getCultureName();
            var Translation=Translations.FirstOrDefault(t=>t.Lang==culture);
            return Translation.Name;
        }

        public void buildTranslation()
        {
            List<string> cultures = CultureHelper.getCultures();
            for(int i=0;i<cultures.Count;i++)
            {
                ProductCategoryTranslation productcategorytranslation = new ProductCategoryTranslation();
                productcategorytranslation.Lang = cultures[i];
                this.Translations.Add(productcategorytranslation);
            }
        }

        public string Name
        {
            get
            {
                return this.getName();
            }
        }

    }
}