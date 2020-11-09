using Mirror;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace WizardDuel.Mirror.Ownership
{
    public class Player : NetworkBehaviour
    {
        [SerializeField] private Vector3 movement = new Vector3();

        [Client]
        private void Update()
        {
            if (!hasAuthority) { return; }

            if(!Input.GetKeyDown(KeyCode.Space)) { return; }

            //transform.Translate(movement);

            CmdMove();
        }

        [Command]
        private void CmdMove()
        {
            // Validate logic here

            RpcMove();
        }

        [ClientRpc]

        private void RpcMove()
        {
            transform.Translate(movement);
        }
    }
}
