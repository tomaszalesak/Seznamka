import { createContext, Dispatch, FC, SetStateAction, useContext, useState } from 'react';

import { User } from '../utils/types';

type UserJwt = {
  jwt: string;
  user: User;
};

type UserState = [UserJwt | undefined, Dispatch<SetStateAction<UserJwt | undefined>>];

const UserContext = createContext<UserState>(undefined as never);

export const UserProvider: FC = ({ children }) => {
  const userState = useState<UserJwt>();
  return <UserContext.Provider value={userState}>{children}</UserContext.Provider>;
};

export const useLogginUser = () => useContext(UserContext);
