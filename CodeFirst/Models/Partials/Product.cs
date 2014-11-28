using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using CodeFirst.Helpers;

namespace CodeFirst.Models
{
    public partial class Product
    {
        private SampleContext db = new SampleContext();

        public static Product Instance
        {
            get { return new Product(); }
        }

        public IEnumerable<Product> findAll()
        {
            return this.db.Products.Include(p => p.ProductCategory).Include(p=>p.Translations);
        }

        public Product findOneById(int id)
        {
            return this.db.Products.Include(p => p.ProductCategory).Include(p=>p.Translations).FirstOrDefault(p => p.Id == id);
        }

        public ProductTranslation getCultureTranslation()
        {
            var culture = CultureHelper.getCultureName();
            var Translation = Translations.FirstOrDefault(t => t.Lang == culture);
            return Translation;
        }

        public void buildTranslations()
        {
            List<string> cultures = CultureHelper.getCultures();
            for (int i = 0; i < cultures.Count; i++)
            {
                ProductTranslation producttranslation = new ProductTranslation();
                producttranslation.Lang = cultures[i];
                Translations.Add(producttranslation);
            }
        }

        public string Name
        {
            get
            {
                var translation = this.getCultureTranslation();
                return translation.Name;
            }
        }

        public string Description
        {
            get
            {
                var translation = this.getCultureTranslation();
                return translation.Description;
            }
        }
    }
}