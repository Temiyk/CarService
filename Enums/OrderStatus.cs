using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursa4.Enums
{
    enum OrderStatus
    {
        Создан = 1,        // Создан
        Делается,     // В работе
        Пауза,         // На паузе
        Ожидание, // Ожидание 
        Отменён,      // Отменен
        Выдать, // Готов к выдаче
        Оплачено,        // Оплачен
        Выполнено,      // Выполнен
    }
}
