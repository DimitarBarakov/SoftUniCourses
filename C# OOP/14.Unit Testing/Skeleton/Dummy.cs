using System;

public class Dummy
{
    private int health;
    private int experience;

    public Dummy(int health, int experience)
    {
        this.health = health;
        this.experience = experience;
    }

    public int Health 
    {
        get { return this.health; }
        set { this.health = value; }
    }
    public int Experience
    {
        get { return this.experience; }
    }

    public void TakeAttack(int attackPoints)
    {
        if (this.IsDead())
        {
            throw new InvalidOperationException("Dummy is dead.");
        }

        this.Health -= attackPoints;
    }

    public int GiveExperience()
    {
        if (!this.IsDead())
        {
            throw new InvalidOperationException("Target is not dead.");
        }

        return this.Experience;
    }

    public bool IsDead()
    {
        return this.Health <= 0;
    }
}
