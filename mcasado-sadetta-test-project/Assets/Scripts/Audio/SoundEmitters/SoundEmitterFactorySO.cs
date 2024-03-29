﻿using UnityEngine;
using MCasado.Factory;

namespace MCasado.AudioSystem
{
    [CreateAssetMenu(fileName = "NewSoundEmitterFactory", menuName = "Factory/SoundEmitter Factory")]
    public class SoundEmitterFactorySO : FactorySO<SoundEmitter>
    {
        public SoundEmitter prefab = default;

        public override SoundEmitter Create()
        {
            return Instantiate(prefab);
        }
    }
}
