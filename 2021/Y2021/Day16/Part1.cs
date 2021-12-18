using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Y2021.Day16
{
    public class Part1
    {
        private readonly ITestOutputHelper _console;

        public class Frame
        {
            public Frame(int v, int t)
            {
                V = v;
                T = t;
            }

            public int V { get; }
            public int T { get; }
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
                        if (i == '0')
                        {
                            frames.Add(new Frame(v, t));
                            count++;
                            frames.AddRange(BuildLengthFrame(v, t));
                        }
                        else
                        {
                            frames.Add(new Frame(v, t));
                            count++;
                            frames.AddRange(BuildCountFrame(v, t));
                        }
                    }

                    if (_count > 0 && count == _count)
                    {
                        return frames;
                    }
                } while (_streamPosition + 7 < _stream.Length);

                return frames;
            }

            private IEnumerable<Frame> BuildCountFrame(int v, int t)
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
                        ++_streamPosition;
                    }
                    ++_streamPosition;
                }

                for (int i = 0; i < 4; i++)
                {
                    ++_streamPosition;
                }
                ++_streamPosition;
                return new Frame(v, t);
            }
        }

        public Part1(ITestOutputHelper console)
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
            var result = frames.Sum(x => x.V);
            _console.WriteLine(result.ToString());
        }
    }
}