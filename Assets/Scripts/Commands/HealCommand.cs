using UnityEngine;
using Command.Main;

namespace Command.Commands
{
    public class HealCommand : UnitCommand
    {
        private bool willHitTarget;

        public HealCommand(int actorUnitId, int targetUnitId, int actorPlayerId, int targetPlayerId)
        {
            ActorUnitID = actorUnitId;
            TargetUnitID = targetUnitId;
            ActorPlayerID = actorPlayerId;
            TargetPlayerID = targetPlayerId;

            willHitTarget = WillHitTarget();
        }

        public override void Execute()
        {
            GameService.Instance.ActionService.GetActionByType(CommandType.Heal).PerformAction(actorUnit, targetUnit, willHitTarget);
        }

        public override void Undo()
        {
            throw new System.NotImplementedException();
        }

        public override bool WillHitTarget() => true;
    }
}