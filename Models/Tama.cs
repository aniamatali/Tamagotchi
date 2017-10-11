using System.Collections.Generic;

namespace Tamagotchi.Models
{
  public class TamaUser
  {
    private string _name;
    private int _food = 100;
    private int _attention = 100;
    private int _rest = 100;

    private static TamaUser liveTama = null;

    public TamaUser(string name)
    {
      _name = name;
    }

    public string GetName()
    {
      return _name;
    }

    public void Save()
    {
      liveTama = this;
    }

    public static TamaUser GetTama()
    {
      return liveTama;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public int GetFood()
    {
      return _food;
    }

    public int GetAttention()
    {
      return _attention;
    }

    public int GetRest()
    {
      return _rest;
    }

    public void GiveFood()
    {
      if(_food >= 100 || _attention >= 100)
      {
        _rest -= 5;
      } else{
        _food += 10;
        _rest -= 5;
        _attention += 5;
      }
    }

    public void GiveAttention()
    {
      if(_attention >= 100){
        _attention -= 20;
      }
      else{
        _attention += 10;
      }
    }

    public void GiveRest()
    {
      if(_rest >= 100){
        _food -= 10;
      }
      else{
      _rest += 10;
      _food -= 10;
    }
    }

    public void PassTime()
    {
      _food -= 15;
      _attention -= 15;
      _rest -= 15;
    }
  }

}
