export type User = {
  id?: number;
  name?: string;
  surname?: string;
  username?: string;
  asswordHash?: string;
  birthdate?: string;
  gender?: number;
  height?: number;
  weight?: number;
  bio?: string;
  longitude?: number;
  latitude?: number;
  chats?: Chat[];
  myBans?: Ban[];
  friendships?: Friendships[];
  references?: Preferences;
  photos?: { image: string }[];
};

export type Friendships = {
  userId?: number;
  user?: User;
  friendId?: number;
  friend?: User;
};

export type Ban = {
  id?: number;
  bannedId?: number;
  bannerId?: number;
  banned?: User;
  banner?: User;
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

export type Message = {
  authorId?: number;
  author?: User;
  chatId?: number;
  chat?: Chat;
  text?: string;
  sendTime?: string; // date, zatim nevim jak
};

export type FindUsers = { users: User[]; totalNumberOfUsers: number };

export type Chat = {
  name: string;
  users: User[];
  messages: string[];
  id: number;
};
