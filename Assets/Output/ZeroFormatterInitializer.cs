#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.Internal
{
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;
    using global::ZeroFormatter.Comparers;

    public static partial class ZeroFormatterInitializer
    {
        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Register()
        {
            // Enums
            ZeroFormatter.Formatters.Formatter<global::MonsterDataBase.VersionType>.Register(new ZeroFormatter.DynamicObjectSegments.VersionTypeFormatter());
            ZeroFormatter.Formatters.Formatter<global::MonsterDataBase.VersionType?>.Register(new ZeroFormatter.DynamicObjectSegments.NullableVersionTypeFormatter());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::MonsterDataBase.VersionType>.Register(new ZeroFormatter.DynamicObjectSegments.VersionTypeEqualityComparer());
            ZeroFormatter.Formatters.Formatter<global::MyFlatBuffers.Data>.Register(new ZeroFormatter.DynamicObjectSegments.MyFlatBuffers.DataFormatter());
            ZeroFormatter.Formatters.Formatter<global::MyFlatBuffers.Data?>.Register(new ZeroFormatter.DynamicObjectSegments.MyFlatBuffers.NullableDataFormatter());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::MyFlatBuffers.Data>.Register(new ZeroFormatter.DynamicObjectSegments.MyFlatBuffers.DataEqualityComparer());
            ZeroFormatter.Formatters.Formatter<global::Test3.FileVersion>.Register(new ZeroFormatter.DynamicObjectSegments.Test3.FileVersionFormatter());
            ZeroFormatter.Formatters.Formatter<global::Test3.FileVersion?>.Register(new ZeroFormatter.DynamicObjectSegments.Test3.NullableFileVersionFormatter());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Test3.FileVersion>.Register(new ZeroFormatter.DynamicObjectSegments.Test3.FileVersionEqualityComparer());
            ZeroFormatter.Formatters.Formatter<global::Test3.LanguageType>.Register(new ZeroFormatter.DynamicObjectSegments.Test3.LanguageTypeFormatter());
            ZeroFormatter.Formatters.Formatter<global::Test3.LanguageType?>.Register(new ZeroFormatter.DynamicObjectSegments.Test3.NullableLanguageTypeFormatter());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Test3.LanguageType>.Register(new ZeroFormatter.DynamicObjectSegments.Test3.LanguageTypeEqualityComparer());
            // Objects
            ZeroFormatter.Formatters.Formatter<global::MonsterDataV1>.Register(new ZeroFormatter.DynamicObjectSegments.MonsterDataV1Formatter());
            ZeroFormatter.Formatters.Formatter<global::MonsterDataV2>.Register(new ZeroFormatter.DynamicObjectSegments.MonsterDataV2Formatter());
            ZeroFormatter.Formatters.Formatter<global::Test3.SettingDataVer1>.Register(new ZeroFormatter.DynamicObjectSegments.Test3.SettingDataVer1Formatter());
            ZeroFormatter.Formatters.Formatter<global::Test3.SettingDataVer2>.Register(new ZeroFormatter.DynamicObjectSegments.Test3.SettingDataVer2Formatter());
            // Structs
            // Unions
            {
                var unionFormatter = new ZeroFormatter.DynamicObjectSegments.MonsterDataBaseFormatter();
                ZeroFormatter.Formatters.Formatter<global::MonsterDataBase>.Register(unionFormatter);
            }
            {
                var unionFormatter = new ZeroFormatter.DynamicObjectSegments.Test3.SettingDataFormatter();
                ZeroFormatter.Formatters.Formatter<global::Test3.SettingData>.Register(unionFormatter);
            }
            // Generics
        }
    }
}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class MonsterDataV1Formatter : Formatter<global::MonsterDataV1>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::MonsterDataV1 value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (4 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<string>(ref bytes, startOffset, offset, 0, value.Name);
                offset += ObjectSegmentHelper.SerializeFromFormatter<uint>(ref bytes, startOffset, offset, 1, value.HitPoint);
                offset += ObjectSegmentHelper.SerializeFromFormatter<float>(ref bytes, startOffset, offset, 2, value.HitRate);
                offset += ObjectSegmentHelper.SerializeFromFormatter<uint>(ref bytes, startOffset, offset, 3, value.Speed);
                offset += ObjectSegmentHelper.SerializeFromFormatter<uint>(ref bytes, startOffset, offset, 4, value.Luck);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 4);
            }
        }

        public override global::MonsterDataV1 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new MonsterDataV1ObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MonsterDataV1ObjectSegment : global::MonsterDataV1, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 0, 4, 4, 4, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        readonly CacheSegment<string> _Name;

        // 0
        public override string Name
        {
            get
            {
                return _Name.Value;
            }
            set
            {
                _Name.Value = value;
            }
        }

        // 1
        public override uint HitPoint
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<uint>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<uint>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override float HitRate
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<float>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<float>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override uint Speed
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<uint>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<uint>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 4
        public override uint Luck
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<uint>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<uint>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public MonsterDataV1ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

            _Name = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (4 + 1));

                offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 0, _Name);
                offset += ObjectSegmentHelper.SerializeFixedLength<uint>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<float>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<uint>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<uint>(ref targetBytes, startOffset, offset, 4, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 4);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class MonsterDataV2Formatter : Formatter<global::MonsterDataV2>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::MonsterDataV2 value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (5 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<string>(ref bytes, startOffset, offset, 0, value.Name);
                offset += ObjectSegmentHelper.SerializeFromFormatter<uint>(ref bytes, startOffset, offset, 1, value.HitPoint);
                offset += ObjectSegmentHelper.SerializeFromFormatter<float>(ref bytes, startOffset, offset, 2, value.HitRate);
                offset += ObjectSegmentHelper.SerializeFromFormatter<uint>(ref bytes, startOffset, offset, 3, value.Speed);
                offset += ObjectSegmentHelper.SerializeFromFormatter<uint>(ref bytes, startOffset, offset, 4, value.Luck);
                offset += ObjectSegmentHelper.SerializeFromFormatter<uint>(ref bytes, startOffset, offset, 5, value.Defense);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 5);
            }
        }

        public override global::MonsterDataV2 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new MonsterDataV2ObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MonsterDataV2ObjectSegment : global::MonsterDataV2, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 0, 4, 4, 4, 4, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        readonly CacheSegment<string> _Name;

        // 0
        public override string Name
        {
            get
            {
                return _Name.Value;
            }
            set
            {
                _Name.Value = value;
            }
        }

        // 1
        public override uint HitPoint
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<uint>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<uint>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override float HitRate
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<float>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<float>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override uint Speed
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<uint>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<uint>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 4
        public override uint Luck
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<uint>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<uint>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 5
        public override uint Defense
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<uint>(__originalBytes, 5, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<uint>(__originalBytes, 5, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public MonsterDataV2ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 5, __elementSizes);

            _Name = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (5 + 1));

                offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 0, _Name);
                offset += ObjectSegmentHelper.SerializeFixedLength<uint>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<float>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<uint>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<uint>(ref targetBytes, startOffset, offset, 4, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<uint>(ref targetBytes, startOffset, offset, 5, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 5);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Test3
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class SettingDataVer1Formatter : Formatter<global::Test3.SettingDataVer1>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Test3.SettingDataVer1 value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (1 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<float>(ref bytes, startOffset, offset, 0, value.MusicVolume);
                offset += ObjectSegmentHelper.SerializeFromFormatter<float>(ref bytes, startOffset, offset, 1, value.EffectsVolume);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::Test3.SettingDataVer1 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new SettingDataVer1ObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class SettingDataVer1ObjectSegment : global::Test3.SettingDataVer1, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 4, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override float MusicVolume
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<float>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<float>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override float EffectsVolume
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<float>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<float>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public SettingDataVer1ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (1 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<float>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<float>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class SettingDataVer2Formatter : Formatter<global::Test3.SettingDataVer2>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Test3.SettingDataVer2 value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (0 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::Test3.LanguageType>(ref bytes, startOffset, offset, 0, value.Language);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Test3.SettingDataVer2 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new SettingDataVer2ObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class SettingDataVer2ObjectSegment : global::Test3.SettingDataVer2, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override global::Test3.LanguageType Language
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<global::Test3.LanguageType>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<global::Test3.LanguageType>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public SettingDataVer2ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<global::Test3.LanguageType>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class MonsterDataBaseFormatter : Formatter<global::MonsterDataBase>
    {
        readonly global::System.Collections.Generic.IEqualityComparer<global::MonsterDataBase.VersionType> comparer;
        readonly global::MonsterDataBase.VersionType[] unionKeys;
        
        public MonsterDataBaseFormatter()
        {
            comparer = global::ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::MonsterDataBase.VersionType>.Default;
            unionKeys = new global::MonsterDataBase.VersionType[2];
            unionKeys[0] = new global::MonsterDataV1().Version;
            unionKeys[1] = new global::MonsterDataV2().Version;
            
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::MonsterDataBase value)
        {
            if (value == null)
            {
                return BinaryUtil.WriteBoolean(ref bytes, offset, false);
            }

            var startOffset = offset;

            offset += BinaryUtil.WriteBoolean(ref bytes, offset, true);
            offset += Formatter<global::MonsterDataBase.VersionType>.Default.Serialize(ref bytes, offset, value.Version);

            if (value is global::MonsterDataV1)
            {
                offset += Formatter<global::MonsterDataV1>.Default.Serialize(ref bytes, offset, (global::MonsterDataV1)value);
            }
            else if (value is global::MonsterDataV2)
            {
                offset += Formatter<global::MonsterDataV2>.Default.Serialize(ref bytes, offset, (global::MonsterDataV2)value);
            }
            
            else
            {
                throw new Exception("Unknown subtype of Union:" + value.GetType().FullName);
            }
        
            return offset - startOffset;
        }

        public override global::MonsterDataBase Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            if (!BinaryUtil.ReadBoolean(ref bytes, offset))
            {
                return null;
            }
        
            offset += 1;
            int size;
            var unionKey = Formatter<global::MonsterDataBase.VersionType>.Default.Deserialize(ref bytes, offset, tracker, out size);
            byteSize += size;
            offset += size;

            global::MonsterDataBase result;
            if (comparer.Equals(unionKey, unionKeys[0]))
            {
                result = Formatter<global::MonsterDataV1>.Default.Deserialize(ref bytes, offset, tracker, out size);
            }
            else if (comparer.Equals(unionKey, unionKeys[1]))
            {
                result = Formatter<global::MonsterDataV2>.Default.Deserialize(ref bytes, offset, tracker, out size);
            }
            else
            {
                throw new Exception("Unknown unionKey type of Union: " + unionKey.ToString());
            }

            byteSize += size;
            return result;
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Test3
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class SettingDataFormatter : Formatter<global::Test3.SettingData>
    {
        readonly global::System.Collections.Generic.IEqualityComparer<global::Test3.FileVersion> comparer;
        readonly global::Test3.FileVersion[] unionKeys;
        
        public SettingDataFormatter()
        {
            comparer = global::ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Test3.FileVersion>.Default;
            unionKeys = new global::Test3.FileVersion[2];
            unionKeys[0] = new global::Test3.SettingDataVer1().Version;
            unionKeys[1] = new global::Test3.SettingDataVer2().Version;
            
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Test3.SettingData value)
        {
            if (value == null)
            {
                return BinaryUtil.WriteBoolean(ref bytes, offset, false);
            }

            var startOffset = offset;

            offset += BinaryUtil.WriteBoolean(ref bytes, offset, true);
            offset += Formatter<global::Test3.FileVersion>.Default.Serialize(ref bytes, offset, value.Version);

            if (value is global::Test3.SettingDataVer1)
            {
                offset += Formatter<global::Test3.SettingDataVer1>.Default.Serialize(ref bytes, offset, (global::Test3.SettingDataVer1)value);
            }
            else if (value is global::Test3.SettingDataVer2)
            {
                offset += Formatter<global::Test3.SettingDataVer2>.Default.Serialize(ref bytes, offset, (global::Test3.SettingDataVer2)value);
            }
            
            else
            {
                throw new Exception("Unknown subtype of Union:" + value.GetType().FullName);
            }
        
            return offset - startOffset;
        }

        public override global::Test3.SettingData Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            if (!BinaryUtil.ReadBoolean(ref bytes, offset))
            {
                return null;
            }
        
            offset += 1;
            int size;
            var unionKey = Formatter<global::Test3.FileVersion>.Default.Deserialize(ref bytes, offset, tracker, out size);
            byteSize += size;
            offset += size;

            global::Test3.SettingData result;
            if (comparer.Equals(unionKey, unionKeys[0]))
            {
                result = Formatter<global::Test3.SettingDataVer1>.Default.Deserialize(ref bytes, offset, tracker, out size);
            }
            else if (comparer.Equals(unionKey, unionKeys[1]))
            {
                result = Formatter<global::Test3.SettingDataVer2>.Default.Deserialize(ref bytes, offset, tracker, out size);
            }
            else
            {
                throw new Exception("Unknown unionKey type of Union: " + unionKey.ToString());
            }

            byteSize += size;
            return result;
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments
{
    using global::System;
    using global::System.Collections.Generic;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;


    public class VersionTypeFormatter : Formatter<global::MonsterDataBase.VersionType>
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::MonsterDataBase.VersionType value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::MonsterDataBase.VersionType Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::MonsterDataBase.VersionType)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }

    public class NullableVersionTypeFormatter : Formatter<global::MonsterDataBase.VersionType?>
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::MonsterDataBase.VersionType? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteInt32(ref bytes, offset + 1, (Int32)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 5);
            }

            return 5;
        }

        public override global::MonsterDataBase.VersionType? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::MonsterDataBase.VersionType)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }

    public class VersionTypeEqualityComparer : IEqualityComparer<global::MonsterDataBase.VersionType>
    {
        public bool Equals(global::MonsterDataBase.VersionType x, global::MonsterDataBase.VersionType y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::MonsterDataBase.VersionType x)
        {
            return (int)x;
        }
    }


}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.MyFlatBuffers
{
    using global::System;
    using global::System.Collections.Generic;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;


    public class DataFormatter : Formatter<global::MyFlatBuffers.Data>
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::MyFlatBuffers.Data value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::MyFlatBuffers.Data Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::MyFlatBuffers.Data)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }

    public class NullableDataFormatter : Formatter<global::MyFlatBuffers.Data?>
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::MyFlatBuffers.Data? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, (Byte)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override global::MyFlatBuffers.Data? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::MyFlatBuffers.Data)BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }

    public class DataEqualityComparer : IEqualityComparer<global::MyFlatBuffers.Data>
    {
        public bool Equals(global::MyFlatBuffers.Data x, global::MyFlatBuffers.Data y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::MyFlatBuffers.Data x)
        {
            return (int)(Byte)x;
        }
    }


}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Test3
{
    using global::System;
    using global::System.Collections.Generic;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;


    public class FileVersionFormatter : Formatter<global::Test3.FileVersion>
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Test3.FileVersion value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::Test3.FileVersion Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::Test3.FileVersion)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }

    public class NullableFileVersionFormatter : Formatter<global::Test3.FileVersion?>
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Test3.FileVersion? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteInt32(ref bytes, offset + 1, (Int32)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 5);
            }

            return 5;
        }

        public override global::Test3.FileVersion? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Test3.FileVersion)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }

    public class FileVersionEqualityComparer : IEqualityComparer<global::Test3.FileVersion>
    {
        public bool Equals(global::Test3.FileVersion x, global::Test3.FileVersion y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::Test3.FileVersion x)
        {
            return (int)x;
        }
    }


    public class LanguageTypeFormatter : Formatter<global::Test3.LanguageType>
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Test3.LanguageType value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::Test3.LanguageType Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::Test3.LanguageType)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }

    public class NullableLanguageTypeFormatter : Formatter<global::Test3.LanguageType?>
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Test3.LanguageType? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteInt32(ref bytes, offset + 1, (Int32)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 5);
            }

            return 5;
        }

        public override global::Test3.LanguageType? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Test3.LanguageType)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }

    public class LanguageTypeEqualityComparer : IEqualityComparer<global::Test3.LanguageType>
    {
        public bool Equals(global::Test3.LanguageType x, global::Test3.LanguageType y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::Test3.LanguageType x)
        {
            return (int)x;
        }
    }


}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
