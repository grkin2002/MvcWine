using System;
namespace MvcWine.Models
{
    public interface IWineRepository
    {
        void AddCountry(Country country);
        void AddWine(Wine wine);
        void AddGrape(Grape grape);
        void AddRegion(Region region);
        void AddSubRegion(SubRegion subRegion);
        void AddProducer(Producer producer);
        void AddProd(Product product);
        void AddTaste(Taste taste);
        void AddPromote(Promote promote);
     
        void DeleteCountry(Country country);
        void DeleteWine(Wine wine);
        void DeleteGrape(Grape grape);
        void DeleteRegion(Region region);
        void DeleteSubRegion(SubRegion subRegion);
        void DeleteProducer(Producer producer);
        void DeleteProd(Product product);
        void DeleteTaste(Taste taste);
        void DeletePromote(Promote promote);


        System.Linq.IQueryable<Country> FindAllCountries();
        System.Linq.IQueryable<Wine> FindAllWines();
        System.Linq.IQueryable<Grape> FindAllGrapes();
        System.Linq.IQueryable<Region> FindAllRegions();
        System.Linq.IQueryable<SubRegion> FindAllSubRegions();
        System.Linq.IQueryable<Producer> FindAllProducers();
        System.Linq.IQueryable<Product> FindAllProds();
        System.Linq.IQueryable<Promote> FindAllPromotes();
        System.Linq.IQueryable<Taste> FindAllTastes();

        
        Country FindCountryByCode(string code);
        Wine FindWineByWineId(int id);
        Grape FindGrapeByGrapeId(int id);
        Region FindRegionByCode( string code);
        SubRegion FindSubRegionByCode(string code);
        Producer FindProducerById(int id);
        Product FindProdById(int id);
        Taste FindTasteById(string id);
        Promote FindPromoteById(string id);

        void Save();
       
    }
}
