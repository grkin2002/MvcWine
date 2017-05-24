using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWine.Models
{
    public class WineRepository: IWineRepository
    {
        #region IWineRepository 成员
        WineDataContext db = new WineDataContext();
        
        public void Save(){db.SubmitChanges();}

        public void AddCountry(Country country){db.Country.InsertOnSubmit(country);}
     
        public void AddWine(Wine wine){db.Wine.InsertOnSubmit(wine);}
    
        public void DeleteCountry(Country country){db.Country.DeleteOnSubmit(country);}
     
        public void DeleteWine(Wine wine){db.Wine.DeleteOnSubmit(wine);}

        public IQueryable<Country> FindAllCountries(){return db.Country;}

        public IQueryable<Wine> FindAllWines(){return db.Wine;}
    
        public Country FindCountryByCode(string code)
        { return db.Country.SingleOrDefault( c=>c.CountryCode==code.Trim());}

        public Wine FindWineByWineId(int id)
        { return db.Wine.SingleOrDefault(w => w.WineId == id); }

        #endregion

        #region Grape 成员

        public void AddGrape(Grape grape){ db.Grape.InsertOnSubmit(grape);}
        
        public void DeleteGrape(Grape grape){db.Grape.DeleteOnSubmit(grape);}
  
        public IQueryable<Grape> FindAllGrapes()
        { return db.Grape;}
  
        public Grape FindGrapeByGrapeId(int id)
        { return db.Grape.SingleOrDefault(g => g.GrapeId == id); }

        #endregion

        #region Region 成员


        public void AddRegion(Region region){db.Region.InsertOnSubmit(region);}
   

        public void DeleteRegion(Region region){db.Region.DeleteOnSubmit(region);}
    

        public IQueryable<Region> FindAllRegions(){return db.Region;}


        public Region FindRegionByCode(string code)
        { return db.Region.SingleOrDefault(r => r.RegionCode == code.Trim()); }
   

        #endregion

        #region SubRegion 成员


        public void AddSubRegion(SubRegion subRegion) { db.SubRegion.InsertOnSubmit(subRegion); }

        public void DeleteSubRegion(SubRegion subRegion) { db.SubRegion.DeleteOnSubmit(subRegion); }

        public IQueryable<SubRegion> FindAllSubRegions() { return db.SubRegion; }

        public SubRegion FindSubRegionByCode(string code)
        { return db.SubRegion.SingleOrDefault(s => s.SubRegionCode == code.Trim()); }

        #endregion

        #region Producer 成员

        public void AddProducer(Producer producer) { db.Producer.InsertOnSubmit(producer); }

        public void DeleteProducer(Producer producer) { db.Producer.DeleteOnSubmit(producer); }

        public IQueryable<Producer> FindAllProducers() { return db.Producer; }

        public Producer FindProducerById(int id)
        { return db.Producer.SingleOrDefault(p => p.ProducerId == id); }

        #endregion

        #region Product 成员


        public void AddProd(Product product) { db.Product.InsertOnSubmit(product); }


        public void DeleteProd(Product product) { db.Product.DeleteOnSubmit(product); }


        public IQueryable<Product> FindAllProds()
        { return db.Product; }

        public Product FindProdById(int id)
        { return db.Product.SingleOrDefault(p => p.ProductId == id); }
           
        

        #endregion

        

       

        #region Taste 成员


        public void AddTaste(Taste taste){db.Taste.InsertOnSubmit(taste);}

        public void DeleteTaste(Taste taste){ db.Taste.DeleteOnSubmit(taste);}

        public IQueryable<Taste> FindAllTastes() { return db.Taste; }

        public Taste FindTasteById(string id){ return db.Taste.SingleOrDefault(t =>t.TasteType==id); }

        #endregion

        #region IWineRepository 成员


        public void AddPromote(Promote promote) { db.Promote.InsertOnSubmit(promote); }


        public void DeletePromote(Promote promote) { db.Promote.DeleteOnSubmit(promote); }


        public IQueryable<Promote> FindAllPromotes() { return db.Promote; }

        public Promote FindPromoteById(string id) { return db.Promote.SingleOrDefault(p => p.PromoteType == id); }


        #endregion
    }
}
