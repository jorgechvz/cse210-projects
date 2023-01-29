using System;
class Fraction{
    private int _numTop;
    private int _numBot;

    public Fraction(){
        _numTop = 1;
        _numBot = 1;
    }
    public Fraction(int _top){
        _numTop = _top;
        _numBot = 1;
    }

    public Fraction(int _topNumber, int _bottomNumber){
        _numTop = _topNumber;
        _numBot = _bottomNumber;
    }

    /* Getters and Setters */
    public int GetFractionTopNumber(){
        return _numTop;
    }

    public void SetFractionTopNumber(int _number){
        _numTop = _number;
    }

    public int GetFractionBotNumber(){
        return _numBot;
    }

    public void SetFractionBotNumber(int _number){
        _numBot = _number;
    }

    public string GetFractionString(){
        string text = $"{_numTop}/{_numBot}";
        return text; 
    }
    public double GetDecimalValue(){
        return (double)_numTop/(double)_numBot;
    }
}