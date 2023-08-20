using System.ComponentModel;

namespace AspDigitalLesson.Model.Enums
{
    /// <summary>
    /// Категории уроков
    /// </summary>
    public enum Category
    {
        [Description("ЕГЭ")]
        Ege = 0,
        
        [Description("ОГЭ")]
        Oge = 1,
        
        [Description("Технические науки")]
        TechnicalSciences = 2,
        
        [Description("Естественные науки")]
        NaturalSciences = 3,
        
        [Description("Гуманитарные науки")]
        HumanitiesSciences = 4,
        
        [Description("Программирование")]
        Programming = 5,
        
        [Description("Школьная программа")]
        SchoolCurriculum = 6,
        
        [Description("Музыка")]
        Musical = 7,
        
        [Description("Искусство")]
        Art = 8,
    }
}