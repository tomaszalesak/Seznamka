import {
  Grid,
  List,
  ListItemButton,
  Avatar,
  ListItemAvatar,
  ListItemText,
  ListItem,
  Divider,
  Fab,
  Paper,
  TextField
} from '@mui/material';
import SendIcon from '@mui/icons-material/Send';
import { useEffect, useRef, useState } from 'react';
import { HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import axios, { Method } from 'axios';

import { Chat, Message } from '../utils/types';
import { useLogginUser } from '../hooks/useLoggedInUser';

const Chats = () => {
  const [logUser, _setLogUser] = useLogginUser();
  //const [selectedChat, setSelectedChat] = useState<Chat>();
  const selectedChat = useRef<Chat>();

  const [chats, setChats] = useState<Chat[]>([]);

  const [messages, setMessages] = useState<Message[]>([]);
  const [fieldValue, setFieldValue] = useState('');

  const [connection, setConnection] = useState<HubConnection>();
  const latestMassages = useRef<Message[]>([]);

  latestMassages.current = messages;

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFieldValue(event.target.value);
  };

  useEffect(() => {
    const newConnection = new HubConnectionBuilder()
      .withUrl('https://localhost:7298/chatHub', {
        accessTokenFactory: () => logUser!.jwt
      })
      .configureLogging(LogLevel.Information)
      .withAutomaticReconnect()
      .build();
    setConnection(newConnection);
  }, []);

  useEffect(() => {
    (async () => {
      if (logUser?.jwt) {
        const config = {
          method: 'get' as Method,
          url: 'https://localhost:7298/api/Chat/mychats',
          headers: {
            accept: 'text/plain',
            Authorization: `Bearer ${logUser.jwt}`
          }
        };
        const { data: chats } = await axios(config);
        setChats(chats);
      }
    })();
  }, []);

  useEffect(() => {
    if (connection) {
      connection
        .start()
        .then(_result => {
          connection.on('ReceiveMessage', (message: string, authorId: number) => {
            if (
              authorId === selectedChat.current?.users[0].id ||
              authorId === selectedChat.current?.users[1].id
            ) {
              const mess: Message = { authorId, text: message };
              const updatedMessages = [...latestMassages.current];
              updatedMessages.push(mess);

              setMessages(updatedMessages);
            }
          });
        })
        .catch(e => console.log('Connection failed: ', e));
    }
  }, [connection]);

  const handleListItemClick = async (chat: Chat) => {
    selectedChat.current = chat;
    if (logUser?.jwt) {
      const config = {
        method: 'get' as Method,
        url: 'https://localhost:7298/api/Chat',
        params: {
          chatId: selectedChat.current.id
        },
        headers: {
          accept: 'text/plain',
          Authorization: `Bearer ${logUser.jwt}`
        }
      };
      const { data: messages } = await axios(config);
      setMessages(messages);
    }
  };

  const addMessage = async () => {
    if (selectedChat.current) {
      if (connection) {
        try {
          await connection.send(
            'SendChatMessage',
            selectedChat.current.id,
            logUser?.user.id,
            selectedChat.current.users.find(element => element.username !== logUser?.user.username)
              ?.username ?? '',
            fieldValue
          );
        } catch (e) {
          console.log(e);
        }
      } else {
        alert('No connection to server yet.');
      }
      setFieldValue('');
    }
  };

  const dateToString = (date: string | undefined) => {
    if (date) {
      const birth = new Date(date);
      return `${birth.getDate()}.${birth.getMonth() + 1}.${birth.getFullYear()}`;
    }
    return 'Now';
  };

  return (
    <Grid container component={Paper} spacing={2} sx={{ height: '92vh' }}>
      <Grid item xs={4}>
        <List
          sx={{
            bgcolor: 'background.paper',
            overflow: 'auto',
            height: '80vh'
          }}
          component="nav"
          aria-label="main mailbox folders"
        >
          {chats.map(item => (
            <ListItemButton
              key={item.id}
              selected={selectedChat?.current?.id === item.id}
              onClick={() => handleListItemClick(item)}
            >
              <ListItemAvatar>
                <Avatar>N</Avatar>
              </ListItemAvatar>
              <ListItemText>
                {item.users.find(element => element.username !== logUser?.user.username)
                  ?.username ?? ''}
              </ListItemText>
            </ListItemButton>
          ))}
        </List>
      </Grid>
      <Grid item xs={8}>
        <List
          sx={{
            bgcolor: 'background.paper',
            overflow: 'auto',
            height: '80vh'
          }}
        >
          {messages.map((item, index) => (
            <ListItem key={index}>
              <Grid container>
                <Grid item xs={12}>
                  <ListItemText
                    sx={{ textAlign: logUser?.user.id === item.authorId ? 'right' : 'left' }}
                    primary={item.text}
                  />
                </Grid>
                <Grid item xs={12}>
                  <ListItemText
                    sx={{ textAlign: logUser?.user.id === item.authorId ? 'right' : 'left' }}
                    secondary={dateToString(item.sendTime)}
                  />
                </Grid>
              </Grid>
            </ListItem>
          ))}
        </List>
        <Divider />
        <Grid container>
          <Grid item xs={11}>
            <TextField
              id="outlined-basic-email"
              label="Type Something"
              size="small"
              value={fieldValue}
              onChange={handleChange}
              fullWidth
            />
          </Grid>
          <Grid item xs={1} sx={{ textAlign: 'right' }}>
            <Fab color="primary" aria-label="add" size="small" onClick={addMessage}>
              <SendIcon />
            </Fab>
          </Grid>
        </Grid>
      </Grid>
    </Grid>
  );
};

export default Chats;
