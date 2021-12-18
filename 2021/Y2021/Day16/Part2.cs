using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Y2021.Day16
{
    public class Part2
    {
        private readonly ITestOutputHelper _console;

        public class Frame
        {
            public Frame(int v, int t)
            {
                V = v;
                T = t;
            }

            public Frame(int v, int t, ulong value) : this(v, t)
            {
                Value = value;
            }

            public int V { get; }
            public int T { get; }
            public ulong Value { get; set; }
        }

        public class FrameBuilder
        {
            private string _stream;
            private int _streamPosition = 0;
            private int _count = 0;

            public int CurrentPosition => _streamPosition;

            public FrameBuilder(string stream)
            {
                _stream = stream;
            }

            public FrameBuilder(string stream, int position, int count)
            {
                _stream = stream;
                _streamPosition = position;
                _count = count;
            }

            public List<Frame> Build()
            {
                var frames = new List<Frame>();
                var count = 0;

                do
                {
                    var v = Convert.ToInt32(_stream[_streamPosition..(_streamPosition += 3)], fromBase: 2);
                    var t = Convert.ToInt32(_stream[_streamPosition..(_streamPosition += 3)], fromBase: 2);

                    if (t == 4)
                    {
                        count++;
                        frames.Add(BuildLiteralFrame(v, t));
                    }
                    else
                    {
                        var i = _stream[_streamPosition];
                        var frame = new Frame(v, t);

                        if (i == '0')
                        {
                            frame.Value = Calculate(BuildLengthFrame(v, t), frame.T);
                        }
                        else
                        {
                            frame.Value = Calculate(BuildCountFrame(v, t), frame.T);
                        }

                        count++;
                        frames.Add(frame);
                    }

                    if (_count > 0 && count == _count)
                    {
                        return frames;
                    }
                } while (_streamPosition + 7 < _stream.Length);

                return frames;
            }

            private ulong Calculate(List<Frame> frames, int t)
            {
                return t switch
                {
                    0 => Sum(frames),
                    1 => Product(frames),
                    2 => Min(frames),
                    3 => Max(frames),
                    5 => Gt(frames[0], frames[1]),
                    6 => Lt(frames[0], frames[1]),
                    7 => Eq(frames[0], frames[1]),
                    _ => throw new NotImplementedException(),
                };
            }

            private List<Frame> BuildCountFrame(int v, int t)
            {
                var count = Convert.ToInt32(_stream[++_streamPosition..(_streamPosition += 11)], 2);

                var builder = new FrameBuilder(_stream, _streamPosition, count);
                var frames = builder.Build();
                _streamPosition = builder.CurrentPosition;

                return frames;
            }

            private List<Frame> BuildLengthFrame(int v, int t)
            {
                var length = Convert.ToInt32(_stream[++_streamPosition..(_streamPosition += 15)], 2);
                var subPackage = _stream[_streamPosition..(_streamPosition += length)];
                var builder = new FrameBuilder(subPackage);

                return builder.Build();
            }

            private Frame BuildLiteralFrame(int v, int t)
            {
                StringBuilder sb = new StringBuilder();
                while (_stream[_streamPosition] == '1')
                {
                    for (int i = 0; i < 4; i++)
                    {
                        sb.Append(_stream[++_streamPosition]);
                    }
                    ++_streamPosition;
                }

                for (int i = 0; i < 4; i++)
                {
                    sb.Append(_stream[++_streamPosition]);
                }
                ++_streamPosition;
                ulong value = Convert.ToUInt64(sb.ToString(), 2);
                return new Frame(v, t, value);
            }

            private ulong Gt(Frame a, Frame b) => a.Value > b.Value ? (ulong)1 : 0;

            private ulong Lt(Frame a, Frame b) => a.Value < b.Value ? (ulong)1 : 0;

            private ulong Eq(Frame a, Frame b) => a.Value == b.Value ? (ulong)1 : 0;

            private ulong Max(List<Frame> frames) => frames.Max(x => x.Value);

            private ulong Min(List<Frame> frames) => frames.Min(x => x.Value);

            private ulong Product(List<Frame> frames) => frames.Select(x => x.Value).Aggregate((a, b) => a * b);

            private ulong Sum(List<Frame> frames) => frames.Select(x => x.Value).Aggregate((a, b) => a + b);
        }

        public Part2(ITestOutputHelper console)
        {
            _console = console;
        }

        [Fact]
        public void Solution()
        {
            var input = InputReader.ReadTo("Day16.txt", lines =>
            {
                return string.Join(string.Empty, lines[0].Select(c => Convert.ToString(Convert.ToUInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
            });

            var fb = new FrameBuilder(input);
            var frames = fb.Build();

            _console.WriteLine(frames[0].Value.ToString());
        }
    }
}