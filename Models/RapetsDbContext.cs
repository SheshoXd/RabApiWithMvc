using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using RabApiWithMvc.Models.Mapping;

namespace RabApiWithMvc.Models
{
    public class RapetsDbContext : DbContext
    {
        static RapetsDbContext()
        {
            Database.SetInitializer<RapetsDbContext>(null);
        }

        public RapetsDbContext()
            : base("Name=RapetsDbContext" )
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.LazyLoadingEnabled = false;
        }
        public IDbSet<Area> Areas { get; set; }
        public IDbSet<Cash> Cashes { get; set; }
        public IDbSet<ClientAccount> ClientAccounts { get; set; }
        public IDbSet<Client> Clients { get; set; }
        public IDbSet<Creadit> Creadits { get; set; }
        public IDbSet<Debit> Debits { get; set; }
        public IDbSet<Employee> Employees { get; set; }
        public IDbSet<GLAccount> GLAccounts { get; set; }
        public IDbSet<Item> Items { get; set; }
        public IDbSet<Journal> Journals { get; set; }
        public IDbSet<Paymant> Paymants { get; set; }
        public IDbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public IDbSet<PurchaseOrdersDetail> PurchaseOrdersDetails { get; set; }
        public IDbSet<SaleOrder> SaleOrders { get; set; }
        public IDbSet<SaleOrdersDetail> SaleOrdersDetails { get; set; }
        public IDbSet<StoreItem> StoreItems { get; set; }
        public IDbSet<StoreMovement> StoreMovements { get; set; }
        public IDbSet<Supplier> Suppliers { get; set; }
        public IDbSet<SuppliersAccount> SuppliersAccounts { get; set; }
        public IDbSet<sysdiagram> sysdiagrams { get; set; }
        public IDbSet<Uint> Uints { get; set; }
        public IDbSet<Vaucher> Vauchers { get; set; }
        public IDbSet<VaucherDetile> VaucherDetiles { get; set; }
        public IDbSet<StoreAccount> StoreAccount { get; set; }
        public IDbSet<Car> Cars { get; set; }
        public IDbSet<CasTody> CasTodies { get; set; }
        public IDbSet<PurchaseAcc> PurchaseAccs { get; set; }
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<RolePermission> RolePermissions { get; set; }
        public IDbSet<UserProfile> UserProfiles { get; set; }
        public IDbSet<UserRole> UserRoles { get; set; }
        public IDbSet<User> Users { get; set; }
        


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AreaMap());
            modelBuilder.Configurations.Add(new CashMap());
            modelBuilder.Configurations.Add(new ClientAccountMap());
            modelBuilder.Configurations.Add(new ClientMap());
            modelBuilder.Configurations.Add(new CreaditMap());
            modelBuilder.Configurations.Add(new DebitMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new GLAccountMap());
            modelBuilder.Configurations.Add(new ItemMap());
            modelBuilder.Configurations.Add(new JournalMap());
            modelBuilder.Configurations.Add(new PaymantMap());
            modelBuilder.Configurations.Add(new PurchaseOrderMap());
            modelBuilder.Configurations.Add(new PurchaseOrdersDetailMap());
            modelBuilder.Configurations.Add(new SaleOrderMap());
            modelBuilder.Configurations.Add(new SaleOrdersDetailMap());
            modelBuilder.Configurations.Add(new StoreItemMap());
            modelBuilder.Configurations.Add(new StoreMovementMap());
            modelBuilder.Configurations.Add(new SupplierMap());
            modelBuilder.Configurations.Add(new SuppliersAccountMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new UintMap());
            modelBuilder.Configurations.Add(new VaucherMap());
            modelBuilder.Configurations.Add(new VaucherDetileMap());
                        modelBuilder.Configurations.Add(new StoreAccountMap());
                        modelBuilder.Configurations.Add(new CarMap());

                        modelBuilder.Configurations.Add(new CasTodyMap());

                        modelBuilder.Configurations.Add(new PurchaseAccMap());

                        modelBuilder.Configurations.Add(new RoleMap());
                        modelBuilder.Configurations.Add(new RolePermissionMap());

                        modelBuilder.Configurations.Add(new UserProfileMap());
                        modelBuilder.Configurations.Add(new UserRoleMap());
                        modelBuilder.Configurations.Add(new UserMap());
      

            //modelBuilder.Entity<Client>().HasRequired(x => x.Area).WithMany().Map(x => x.MapKey("AreaId"));
            //modelBuilder.Entity<Supplier>().HasRequired(x => x.Area).WithMany().Map(x => x.MapKey("AreaId"));
        }

       
    }
}
