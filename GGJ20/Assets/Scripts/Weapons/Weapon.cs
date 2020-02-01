using System;
public class Weapon
{
    public String _name;
    public int _damages;
    public int _range;
    public float _cooldown;
    public bool _isBroken;

    public Weapon(String name, int damages, int range, float cooldown, bool isBroken)
    {
        this._name = name;
        this._damages = damages;
        this._range = range;
        this._cooldown = cooldown;
        this._isBroken = isBroken;
    }
}
