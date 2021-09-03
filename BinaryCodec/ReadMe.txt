Project structure is as follows:

Main part of project is .NET Standard library BinaryCodec. It contains whole logic related to encoding and decoding given messages. It supports all restrictions proposed in assignment description. 
For this specific case i suggested following schema.
Encoded message starts with one byte which holds number of headers provided within coded message. It allows program to always decode right number of headers without worrying about checking if bytes are still belonging to header or are they already a part of a payload.
To avoid additional computional complexity i've encoded each header like this:
- {4 bytes holding integer which describes length of header key}{header key bytes}{4 bytes holding integer which describes length of header value}{header value bytes}
Repeating this for known number of time (based on header number encoded in first byte) makes all the complexity be reading specified number of bytes from stream
Last part is payload which is encoded pretty much the same way as each header:
- {4 bytes describing length of payload}{payload bytes}