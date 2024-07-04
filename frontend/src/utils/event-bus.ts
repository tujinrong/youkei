//envent事件
import mitt, { Emitter, EventType } from 'mitt'

export interface Mitter extends Emitter<Record<EventType, unknown>> {
  clearKey(name: string): void
  once(name: string, data: any): void
}

const emitter: Mitter = mitt() as Mitter

emitter.clearKey = (name) => {
  emitter.all.delete(name)
}

emitter.once = (name, data) => {
  emitter.clearKey(name)
  emitter.on(name, data)
}

export default emitter
