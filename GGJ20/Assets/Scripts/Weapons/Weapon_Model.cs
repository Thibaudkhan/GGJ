using System;
public class Weapon_Model
{
    public String _name;
    public int _damages;
    public int _frame_active;
    public float _cooldown;
    public bool _isBroken;

    public Weapon_Model(String name, int damages, int frame_active, float cooldown, bool isBroken)
    {
        this._name = name;
        this._damages = damages;
        this._frame_active = frame_active;
        this._cooldown = cooldown;
        this._isBroken = isBroken;
    }
}
