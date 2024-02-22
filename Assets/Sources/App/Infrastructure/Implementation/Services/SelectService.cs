using Sources.App.Presentations;
using Sources.Domain.Models.SpotLamps;

namespace Sources.App.Services
{
    public class SelectService
    {
        public ISelect SelectedObject { get; private set; }

        public void ChangeSelect(SpotLampView view)
        {
            SelectedObject = view?.GetModel();
        }
    }
}