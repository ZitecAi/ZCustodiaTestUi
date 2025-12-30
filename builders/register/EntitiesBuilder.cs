using Microsoft.Playwright;
using zCustodiaUi.data.register;
using zCustodiaUi.pages.register;
using zCustodiaUi.utils;

namespace zCustodiaUi.builders.register
{
    public class EntitiesBuilder
    {
        private readonly EntitiesPage _page;
        private readonly Utils _util;
        private readonly List<Func<Task>> _steps = new();

        public EntitiesBuilder(IPage page, EntitiesData data = null)
        {
            _page = new EntitiesPage(page, data);
            _util = new Utils(page);
        }




    }
}
