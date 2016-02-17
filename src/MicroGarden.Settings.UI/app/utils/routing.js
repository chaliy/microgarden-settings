import { hashHistory } from 'react-router';

export const redirectTo = path => hashHistory.push(path);
