// using UnityEngine;
//
// namespace Lessons.AI.Architecture
// {
//     public sealed class SequenceTask : Task, ITaskCallback
//     {
//         [SerializeField]
//         private Task[] children;
//
//         private int pointer;
//
//         private Task currentTask;
//
//         protected override void Do()
//         {
//             if (this.children is not {Length: > 0})
//             {
//                 this.Return(true);
//                 return;
//             }
//
//             this.pointer = 0;
//             this.currentTask = children[this.pointer];
//             this.currentTask.Do(callback: this);
//         }
//
//         protected override void OnCancel()
//         {
//             if (this.currentTask != null && this.currentTask.IsPlaying)
//             {
//                 this.currentTask.Cancel();
//             }
//         }
//
//         void ITaskCallback.OnComplete(Task task, bool success)
//         {
//             if (!success)
//             {
//                 this.Return(false);
//                 return;
//             }
//
//             if (this.pointer + 1 >= this.children.Length)
//             {
//                 this.Return(true);
//                 return;
//             }
//
//             this.pointer++;
//             this.currentTask = this.children[this.pointer];
//             this.currentTask.Do(callback: this);
//         }
//     }
// }