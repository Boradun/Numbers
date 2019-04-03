using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerModel
{
    public class PlayerBase
    {
        // свойства, которые сохранятся в БД
        //[Key]
        public int PlayerBaseId { get; set; }
        
        public string PlayerName { get; set; }

        public int PlayerScore { get; set; }

        public string PlayerPassword { get; set; }

        //поле, доступное через свойство только для чтения
        //хранит пароль
        //задается при создании нового игрока только 1 раз
        //private string _playerPass;

        public PlayerBase()
        {
            PlayerBaseId = -1;
            PlayerName = "Гость";
            PlayerScore = 0;
        }

        ///изменяет пароль, если успешно то вернет true
        /*
        public bool SetPassword(string newPassword)
        {
            if (newPassword != null)
            {
                _playerPass = newPassword;
                return true;
            }
            return false;
        }*/
    }
}
