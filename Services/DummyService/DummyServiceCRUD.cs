using MondayFunday.Services.Interfaces;

namespace MondayFunday.Services.DummyService
{
    public class DummyServiceCRUD : IDummyInterface
    {
        //public string GetData()
        //{
        //    return "This is dummy data from the service.";
        //}

        public string GetData()
        {
            return "Lite dummy datas";
        }

        public string GetDataById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
