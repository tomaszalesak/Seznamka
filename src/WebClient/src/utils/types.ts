export type User = {
  name?: string;
  surname?: string;
  username?: string;
  asswordHash?: string;
  birthdate?: string; // date, zatim nevim jak
  gender?: number;
  height?: number;
  weight?: number;
  bio?: string;
  longitude?: number;
  latitude?: number;
  chats?: Chat[];
  blockedUsers?: User[];
  friendships?: string[]; //friedsihp dto neni
  references?: Preferences;
  photo?: { image: string }[];
};

export type Preferences = {
  minAge?: number;
  maxAge?: number;
  minWeight?: number;
  maxWeight?: number;
  minHeight?: number;
  maxHeight?: number;
  gpsRadius?: number;
};

export type Chat = {
  name?: string;
  memberOne?: User;
  memberTwoId?: number;
  memberTwo?: User;
  messages?: Message;
};

export type Message = {
  authorId?: number;
  author?: User;
  chatId?: number;
  chat?: Chat;
  text?: string;
  sendTime?: string; // date, zatim nevim jak
};

export type FindUsers = { users: User[]; totalNumberOfUsers: number };

export type Bans = {
  id?: number;
  banned?: {
    name?: string;
    surname?: string;
    username?: string;
    id?: 1;
  };
};
