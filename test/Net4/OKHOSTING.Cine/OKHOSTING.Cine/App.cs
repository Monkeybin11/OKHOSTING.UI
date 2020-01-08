using OKHOSTING.Cine.Model;
using OKHOSTING.ORM;
using OKHOSTING.ORM.Operations;
using System;
using System.Linq;

namespace OKHOSTING.Cine
{
    public class App : OKHOSTING.UI.App
    {
        public void Start()
        {
            Core.BaitAndSwitch.PlatformSpecificConstructors.Add(typeof(DataBase), DataBase_Setup);
            MapTypes();

            var select = new OKHOSTING.ORM.Operations.Select<Sala>();
            var selectController = new OKHOSTING.ORM.UI.SelectController(this.MainPage, select);

            var login = new OKHOSTING.Security.UI.Login(this.MainPage);
            login.Authentication = new OKHOSTING.ORM.Security.Authentication();

            login.NextController = selectController;
            login.Start();

        }

        public static DataBase DataBase_Setup()
        {
            Core.AppConfig config = new OKHOSTING.Core.AppConfig();

            var db = new DataBase(new OKHOSTING.SQL.DbProviders.MySql.Client() { ConnectionString = config.GetAppSetting("connectionString") }, new OKHOSTING.SQL.DbProviders.MySql.SQLGenerator());
            db.BeforeOperation += Db_BeforeOperation;


            return db;
        }
        private static void Db_BeforeOperation(DataBase sender, OperationEventArgs eventArgs)
        {
            if (eventArgs.Operation is Insert && eventArgs.Operation.DataType.PrimaryKey.Count() == 1 && eventArgs.Operation.DataType.PrimaryKey.Single().Expression.ReturnType.Equals(typeof(Guid)))
            {
                var pk = eventArgs.Operation.DataType.PrimaryKey.Single();
                object instance = ((Insert)eventArgs.Operation).Instance;
                Guid pkValue = (Guid)pk.Expression.GetValue(instance);

                //create new Guid before insert, if current value is empty
                if (pkValue.Equals(Guid.Empty))
                {
                    pk.SetValueFromColumn(instance, Guid.NewGuid());
                }
            }
        }
        public static void MapTypes()
        {
            var types = typeof(Persona).Assembly.DefinedTypes.ToList();
            types.AddRange(typeof(OKHOSTING.Security.User).Assembly.DefinedTypes);

            var dtypes = DataType.CreateDataTypes(types).ToList();

            var dtype = DataType<OKHOSTING.Security.User>.GetDataType();
            var converter = new OKHOSTING.ORM.Cryptography.EncryptStringConverter("ASDjgh67sda76576gjhsdfgjhdsw@#$$#$#");
            dtype[m => m.Password].Converter = converter;



            //var db = OKHOSTING.Core.BaitAndSwitch.Create<DataBase>();
            //db.CreateIfNotExist(DataType.AllDataTypes);
            //var user = new OKHOSTING.Security.InApp.User();
            //user.UserName = "root";
            //user.Password = "123";
            //db.Insert(user);
        }
    }
}

