import { MessageType } from './../models/message-type.model';
import { Message } from './../models/message.model';


export class FunctionsService {

  public static hasErrors( messages: Array<Message>): boolean {
    let resultado = false;

    messages.forEach(m => {
      if (m.type == MessageType.Error){
        resultado = true;
      }
    });
    return resultado;
  }
}
