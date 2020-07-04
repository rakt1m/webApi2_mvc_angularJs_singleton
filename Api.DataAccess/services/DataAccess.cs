namespace Api.DataAccess.services
{
    public class DataAccess
    {
        private static DataAccess _DataAccess;

        // public CommonServices CommonServices = new CommonServices();
        private static object _sync = new object();

        public static DataAccess Instance
        {
            get
            {
                if (_DataAccess == null)
                {
                    lock (_sync)
                    {
                        if (_DataAccess == null)
                        {
                            _DataAccess = new DataAccess();
                        }
                    }
                }
                return _DataAccess;
            }
        }

        //service 

        public EmployeeService EmployeeService = new EmployeeService();


    }
}
