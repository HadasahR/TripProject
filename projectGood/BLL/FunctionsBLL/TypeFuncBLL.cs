using AutoMapper;
using BLL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.FunctionsBLL
{
    public class TypeFuncBLL : ITypeBLL
    {
        //DAL הגדרת משתנה מסוג הממשק של ה
      private readonly  DAL.Interfaces.ITypes typesDal;
        //Mapper הגדרת ה
      private readonly  IMapper mapper;
        //הזרקת הממשקים בבנאי והצבתם במשתנים 
        public TypeFuncBLL(DAL.Interfaces.ITypes t,IMapper map) {
          this.typesDal = t;
            this.mapper = map;
        }
        public async Task<int> addAsync(DTO.Classes.TypeDTO typeDTO)
        {
            //שליפת כל הסוגים 
            List<DTO.Classes.TypeDTO> allTypes= getAllAsync();
            //מציאה אם קיים כבר אחד כזה 
            var newType=allTypes.Find(e=>e.Equals(typeDTO));
            //אם קיים אחד כזה 
            if (newType!=null)
            {
                return -1;
            }
            //אם לא קיים נוסיף אותו 
            int i = await typesDal.addAsync(mapper.Map<DTO.Classes.TypeDTO, DAL.Models.Type>(typeDTO));
            return i;
        }
        public  List<DTO.Classes.TypeDTO> getAllAsync()
        {
            //DALהגדרת רשימה מפונקצית השליפה מה
            var list =  typesDal.getAllAsync();
            // והחזרתה DTOהמרת הרשימה ל
            return mapper.Map<List<DTO.Classes.TypeDTO>>(list);
        }

        public  async Task<bool> removeAsync(int id)
        {
            //שליפת כל הסוגים 
            List<DTO.Classes.TypeDTO> allTypes =  getAllAsync();
            //מציאה אם קיים  אחד  
            DTO.Classes.TypeDTO newType = allTypes.Find(e => e.TypeId==id);
            //אם כן נוריד אותו 

            if (newType!=null)
            {
                return await typesDal.deleteAsync(newType.TypeId);
            }
            return false;
        }
    }
}
