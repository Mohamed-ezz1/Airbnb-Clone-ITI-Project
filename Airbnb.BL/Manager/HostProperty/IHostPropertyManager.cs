using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL;

public interface IHostPropertyManager
{
    PropertyGetAddDto? GetAddPropertyLists();
    PropertyGetUpdateDto? GetUpdatePropertyContent(Guid id);
    void postAddPropertyHost(PropertyPostAddDto propertyPostAddDto);
    bool UpdateHostProperty(PropertyPostUpdateDto propertyPostUpdateDto);
}
