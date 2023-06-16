namespace UI.Buttons
{
    public sealed class RandomShootButton : ShootButton
    {
        protected override void Shoot()
        {
            PlayerShooter.Shoot(ShootersDistributor.GetRandomEnemy().transform.position);
        }
    }
}