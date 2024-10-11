using Components;
using Animations;
using Zenject;
using UnityEngine;
using Controllers;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // ����������� CharacterController �� ��������
        Container.Bind<CharacterController>()
                 .FromComponentInHierarchy()
                 .AsSingle()
                 .NonLazy();

        // ����������� Animator �� ��������
        Container.Bind<Animator>()
                 .FromComponentInHierarchy()
                 .AsSingle()
                 .NonLazy();

        // ����������� WeaponComponent
        Container.Bind<WeaponComponent>()
                 .FromComponentInHierarchy()
                 .AsSingle()
                 .NonLazy();

        // ����������� AttackComponent
        Container.Bind<AttackComponent>()
                 .FromComponentInHierarchy()
                 .AsSingle()
                 .NonLazy();

        // ����������� AnimatorTrigger ��� ��������
        Container.Bind<ShootAnimatorTrigger>()
                 .FromComponentInHierarchy()
                 .AsSingle()
                 .NonLazy();

        // ����������� AnimatorTrigger ��� �����
        Container.Bind<PunchAnimatorTrigger>()
                 .FromComponentInHierarchy()
                 .AsSingle()
                 .NonLazy();

        // ����������� FireController
        Container.Bind<FireController>()
                 .FromComponentInHierarchy()
                 .AsSingle()
                 .NonLazy();

        // ����������� AnimatorTrigger ��� ������
        Container.Bind<MovementAnimatorController>()
            .FromComponentInHierarchy()
            .AsSingle()
            .NonLazy();
    }
}
