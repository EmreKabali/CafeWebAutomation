using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity.Enums
{
    public  enum IsDeleted
    {

        //Veri silme işlemlerinde verileri silmek yerine durumunu değiştirmek adına oluşturdugum alan 
        //Örneğin veri silmek istendiğinde IsDeleted.delete olacaktır görüntüleme işlemlerinde IsDeleted.active olanlar görüntülenecek

        active=1,
        delete=0



    }
}
