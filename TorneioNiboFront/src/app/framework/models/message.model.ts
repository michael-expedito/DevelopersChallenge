import { MessageType } from './message-type.model';

export class Message {

  constructor(
    public code: String,
    public type: MessageType,
    public description: String
  ) {}

}
