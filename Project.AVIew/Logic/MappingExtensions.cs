using Project.AVIew.Models;

namespace Project.AVIew.Logic
{
    public static class MappingExtensions
    {
        public static LoginServiceModel ToServiceModel(this LoginBindingModel source)
        {
            return new LoginServiceModel()
            {
                Email = source.Login,
                Password = source.Password
            };
        }
    }

}
