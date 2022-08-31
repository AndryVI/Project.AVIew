using System;

namespace Project.AVIew.Model
{
    public class Values
    {
        public double Temperature { get; set; }     //температуры  Цельсия [-90,60]  Фаренгейта[-130, 140]
        public WeatherCodes? WeatherCode { get; set; }//
        public double? Humidity { get; set; }        //Концентрация водяного пара в воздухе %
        public double? WindSpeed { get; set; }       //м/с миль/ч
        public double? WindDirection { get; set; }   // градусы или ноль	
        public double? PrecipitationIntensity { get; set; }   //интенсивности осадков путем  мм/час дюйм/час
        public double? PrecipitationProbability { get; set; }   //  осадков представляет собой вероятность >0,0254 см (0,01 дюйма)
        public PrecipitationTypes? PrecipitationType { get; set; }   //  осадков представляет собой вероятность >0,0254 см (0,01 дюйма)
        public double? Visibility { get; set; }   //  объект или свет можно четко различить - км миль
        public double? CloudCover { get; set; }   //  часть неба, закрытая облаками при наблюдении %
        public GrassIndexs? GrassIndex { get; set; }   //  осадков представляет собой вероятность >0,0254 см (0,01 дюйма)
    }
}