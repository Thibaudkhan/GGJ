using System;
public class Enemy_Model {
    public String _name;
    public int _damages;
    public int _range;
    public float _cooldown;
    public int _hp;
    public String _type;
    public int _speed;
    public Boolean isAlive;
    public int _aggroRange;



    public Enemy_Model(String name, int damages, int range, float cooldown, int hp, String type, int speed, bool isAlive, int aggroRange) {
        this._name = name;
        this._damages = damages;
        this._range = range;
        this._cooldown = cooldown;
        this._hp = hp;
        this._type = type;
        this._speed = speed;
        this.isAlive = isAlive;
        this._aggroRange = aggroRange;
        }
    }
