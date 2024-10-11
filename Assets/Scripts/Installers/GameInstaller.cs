using Components;
using Animations;
using Zenject;
using UnityEngine;
using Controllers;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // Регистрация CharacterController из иерархии
        Container.Bind<CharacterController>()
                 .FromComponentInHierarchy()
                 .AsSingle()
                 .NonLazy();

        // Регистрация Animator из иерархии
        Container.Bind<Animator>()
                 .FromComponentInHierarchy()
                 .AsSingle()
                 .NonLazy();

        // Регистрация WeaponComponent
        Container.Bind<WeaponComponent>()
                 .FromComponentInHierarchy()
                 .AsSingle()
                 .NonLazy();

        // Регистрация AttackComponent
        Container.Bind<AttackComponent>()
                 .FromComponentInHierarchy()
                 .AsSingle()
                 .NonLazy();

        // Регистрация AnimatorTrigger для стрельбы
        Container.Bind<ShootAnimatorTrigger>()
                 .FromComponentInHierarchy()
                 .AsSingle()
                 .NonLazy();

        // Регистрация AnimatorTrigger для удара
        Container.Bind<PunchAnimatorTrigger>()
                 .FromComponentInHierarchy()
                 .AsSingle()
                 .NonLazy();

        // Регистрация FireController
        Container.Bind<FireController>()
                 .FromComponentInHierarchy()
                 .AsSingle()
                 .NonLazy();

        // Регистрация AnimatorTrigger для ходьбы
        Container.Bind<MovementAnimatorController>()
            .FromComponentInHierarchy()
            .AsSingle()
            .NonLazy();
    }
}
